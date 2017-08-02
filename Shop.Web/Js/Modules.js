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
    app.controller("BooksController", function ($scope, $http) {
        $scope.SearchPhrase = null;
        $scope.Result = [];
        $scope.DataList = [];
        $scope.sortType = "name";
        $scope.sortReverse = true;
        $scope.IsBookType = null;
        $scope.IsNewType = null;
        $scope.RestrictSearchPhrase = function (value, max) {
            if (value > max) {
                return false;
            }
        };
        $scope.FindBook = function (phrase) {
            console.log(phrase);
        };
        $http.get('/Books/GetAllBooks').then(function (d) {
            $scope.DataList = d.data;
            console.log(d.data);
        }, function (error) {
            alert('FAIL');
        });
        $scope.TabList = [{
                title: 'Wszystkie',
                active: true,
                BookType: BooksType.All,
                template: "/HtmlTemplate/Books/TabList.html"
            }, {
                title: 'Audioboki',
                active: false,
                BookType: BooksType.AudioBooks,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'E-Booki',
                active: false,
                BookType: BooksType.EBooks,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'Nowości',
                active: false,
                BookType: BooksType.News,
                template: "/HtmlTemplate/Books/TabList.html"
            },
            {
                title: 'Zapowiedzi',
                active: false,
                BookType: BooksType.Upcoming,
                template: "/HtmlTemplate/Books/TabList.html"
            }, {
                title: 'Super Okazje',
                active: false,
                BookType: BooksType.SuperOccasions,
                template: "/HtmlTemplate/Books/TabList.html"
            }
        ];
        function Search() {
        }
        $scope.LoadData = function (booksType) {
            return GetData(booksType, null);
        };
        function GetData(booksType, searchPhrase) {
            $scope.IsBookType = booksType;
            var apiUrl = '';
            switch (booksType) {
                case BooksType.All:
                    {
                        apiUrl = '/Books/GetAllBooks';
                    }
                    break;
                case BooksType.AudioBooks:
                    {
                        apiUrl = '/Books/GetAudioBooks';
                    }
                    break;
                case BooksType.EBooks:
                    {
                        apiUrl = '/Books/GetEBooks';
                    }
                    break;
                case BooksType.News:
                    {
                        apiUrl = '/Books/GetNews';
                    }
                    break;
                case BooksType.Upcoming:
                    {
                        apiUrl = '/Books/GetUpComming';
                    }
                    break;
                case BooksType.SuperOccasions:
                    {
                        apiUrl = '/Books/GetPromotions';
                    }
                    break;
                default:
            }
            $http.get(apiUrl).then(function (d) {
                $scope.DataList = d.data;
            }, function (error, status) {
                console.log(error, status);
            });
        }
    });
})(BooksModule || (BooksModule = {}));
