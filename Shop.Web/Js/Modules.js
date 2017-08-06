/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />
var BooksModule;
(function (BooksModule) {
    var app = angular.module("MyBooks", ['ui.bootstrap', 'ngSanitize']);
    app.filter("DateFormat", function () {
        return function (rawDate) {
            return new Date(parseInt(rawDate.substr(6)));
        };
    });
    app.filter("PriceFormat", function () {
        return function (rawPrice) {
            return (rawPrice.toFixed(2));
        };
    });
    var BooksType;
    (function (BooksType) {
        BooksType[BooksType["All"] = 1] = "All";
        BooksType[BooksType["AudioBooks"] = 2] = "AudioBooks";
        BooksType[BooksType["EBooks"] = 3] = "EBooks";
        BooksType[BooksType["News"] = 4] = "News";
        BooksType[BooksType["Upcoming"] = 5] = "Upcoming";
        BooksType[BooksType["SuperOccasions"] = 6] = "SuperOccasions";
    })(BooksType || (BooksType = {}));
    function GetApiUrlByBookType(booksType, searchData) {
        var apiUrl = "";
        var searchByParam = searchData !== null;
        switch (booksType) {
            case BooksType.All:
                {
                    apiUrl = searchByParam ? '/Books/FindBookAll' : '/Books/GetAllBooks';
                }
                break;
            case BooksType.AudioBooks:
                {
                    apiUrl = searchByParam ? '/Books/FindBookAudiotbooks' : '/Books/GetAudioBooks';
                }
                break;
            case BooksType.EBooks:
                {
                    apiUrl = searchByParam ? '/Books/FindEBook' : '/Books/GetEBooks';
                }
                break;
            case BooksType.News:
                {
                    apiUrl = searchByParam ? '/Books/FindNews' : '/Books/GetNews';
                }
                break;
            case BooksType.Upcoming:
                {
                    apiUrl = searchByParam ? '/Books/FindUpcomming' : '/Books/GetUpComming';
                }
                break;
            case BooksType.SuperOccasions:
                {
                    apiUrl = searchByParam ? '/Books/FindPromotions' : '/Books/GetPromotions';
                }
                break;
            default:
        }
        return apiUrl;
    }
    app.controller("BooksController", function ($scope, $http) {
        $scope.isLoading = true;
        $scope.IsBookType = 1;
        $scope.SearchPhrase;
        $scope.DataIsNull = false;
        $scope.DataList = [];
        $scope.sortType = "name";
        $scope.sortReverse = true;
        $scope.IsBookType = null;
        $scope.IsNewType = null;
        $scope.showModal = false;
        $scope.open = function () {
            $scope.showModal = !$scope.showModal;
        };
        $scope.SearchPhraseIsValid = function (data, max) {
            if (data !== undefined && parseInt(data) > max) {
                return false;
            }
            return true;
        };
        $scope.FindBook = function (phrase) {
            $scope.DataList = null;
            $scope.IsBookType == null ? 1 : $scope.IsBookType;
            if (phrase !== undefined) {
                if (parseInt(phrase) > 0 && parseInt(phrase) < 11) {
                    var apiUrl = GetApiUrlByBookType($scope.IsBookType, phrase);
                    console.log($scope.IsBookType, phrase, apiUrl);
                    $http.post(apiUrl, {
                        "search": phrase
                    }).then(function (fillFuled) {
                        if (fillFuled !== null && fillFuled.data.length > 0) {
                            $scope.DataIsNull = false;
                            $scope.DataList = fillFuled.data;
                        }
                        else
                            $scope.DataIsNull = true;
                    });
                }
                if (parseInt(phrase) == 0) {
                    GetData($scope.IsBookType == null ? 1 : $scope.IsBookType);
                }
            }
        };
        // Emit Event 
        $scope.$on('RefreshPrudcts', function (event) {
            $http.get('/Orders/GetOrdersList').then(function (fillFulled) {
                if (fillFulled.data !== null) {
                    console.log(fillFulled.data);
                    $scope.productCount = fillFulled.data;
                }
                else
                    $scope.productCount = 0;
            }, function (error) {
                alert(error);
            });
        });
        //OnLoad
        $http.get('/Orders/GetOrdersList').then(function (fillFulled) {
            if (fillFulled.data !== null) {
                console.log(fillFulled.data);
                $scope.productCount = fillFulled.data;
                console.log($scope.productCount);
            }
            else
                $scope.productCount = 0;
        }, function (error) {
            alert(error);
        });
        {
            $scope.isLoading = true;
            $http.get('/Books/GetAllBooks').then(function (d) {
                $scope.DataList = d.data;
                $scope.isLoading = false;
            }, function (error) {
                $scope.isLoading = false;
                alert('FAIL');
            });
        }
        // Tab list
        $scope.TabList = [{
                title: 'Wszystkie',
                active: true,
                SearchBy: BooksType.All,
                template: "/HtmlTemplate/Books/TabList.html"
            }, {
                title: 'Audioboki',
                active: false,
                SearchBy: BooksType.AudioBooks,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'E-Booki',
                active: false,
                SearchBy: BooksType.EBooks,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'Nowości',
                active: false,
                SearchBy: BooksType.News,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'Zapowiedzi',
                active: false,
                SearchBy: BooksType.Upcoming,
                template: "/HtmlTemplate/Books/TabList.html"
            }, {
                title: 'Super Okazje',
                active: false,
                SearchBy: BooksType.SuperOccasions,
                template: "/HtmlTemplate/Books/TabList.html"
            }
        ];
        $scope.LoadData = function (booksType) {
            $scope.DataList = null;
            $scope.isLoading = true;
            return GetData(booksType);
        };
        // Load Data on Tab click
        function GetData(booksType) {
            $scope.IsBookType = booksType;
            var apiUrl = GetApiUrlByBookType(booksType, null);
            $http.get(apiUrl).then(function (d) {
                if (d !== null && d.data.length > 0) {
                    $scope.DataList = d.data;
                    $scope.isLoading = false;
                }
            }, function (error, status) {
                $scope.isLoading = false;
                console.log(error, status);
            });
        }
        $scope.IsModalVisible = false;
        $scope.open = function () {
            $scope.IsModalVisible = !$scope.IsModalVisible;
        };
    });
    //Modal Cart
    app.directive('modal', function () {
        return {
            templateUrl: '/HtmlTemplate/ShopCart/ModalCart.html',
            restrict: 'E',
            transclude: true,
            replace: true,
            scope: true,
            link: function postLink(scope, element, attrs) {
                scope.$watch(attrs.visible, function (value) {
                    if (value == true)
                        $(element).modal('show');
                    else
                        $(element).modal('hide');
                });
                $(element).on('shown.bs.modal', function () {
                    scope.$apply(function () {
                        scope.$parent[attrs.visible] = true;
                    });
                });
                $(element).on('hidden.bs.modal', function () {
                    scope.$apply(function () {
                        scope.$parent[attrs.visible] = false;
                    });
                });
            }
        };
    });
    app.controller("CartController", function ($scope, $http) {
        $scope.SelectedEdtion;
        $scope.SelectedCovers;
        $scope.SelectedPublisher;
        $scope.SelectedMedium;
        $scope.Quantity = 1;
        //Modal Cart Selection onLoad
        $http.get("Covers/GetCovers").then(function (fillFulled) {
            if (fillFulled.data !== null) {
                $scope.CoversList = fillFulled.data;
            }
        }, function (errorHandler) {
            console.log(errorHandler);
        });
        $http.get("Publishers/GetPublishers").then(function (fillFulled) {
            if (fillFulled.data !== null) {
                $scope.PublisherList = fillFulled.data;
            }
        }, function (errorHandler) {
            console.log(errorHandler);
        });
        $http.get("Mediums/GetMediums").then(function (fillFulled) {
            if (fillFulled.data !== null) {
                $scope.MediumsList = fillFulled.data;
            }
        }, function (errorHandler) {
            console.log(errorHandler);
        });
        $http.get("Editions/GetEdition").then(function (fillFulled) {
            if (fillFulled.data !== null) {
                $scope.EditionsList = fillFulled.data;
            }
        }, function (errorHandler) {
            console.log(errorHandler);
        });
        //End Modal Cart Selection onLoad
        $scope.AddToCart = function () {
            var product = [{
                    "CoverId": $scope.SelectedCovers.Id,
                    "EditionId": $scope.SelectedEdtion.Id,
                    "MediumId": $scope.SelectedMedium.Id,
                    "PublisherId": $scope.SelectedPublisher.Id
                }];
            $http.post("Orders/OrderBook", {
                "item": {
                    "Quantity": $scope.Quantity,
                    "Product": product
                }
            }).then(function (fillFulled) {
                $scope.$emit('RefreshPrudcts');
            });
        };
        $scope.ValidateQuantity = function (data) {
            if (data > 999 || data < 1)
                return false;
            return true;
        };
        $scope.ValidateForm = function (cover, edition, publisher, medium, quantity) {
            return cover != undefined && edition != undefined && publisher != undefined && medium != undefined && $scope.ValidateQuantity(quantity);
        };
    });
})(BooksModule || (BooksModule = {}));
