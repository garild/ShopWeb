/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-resource.d.ts" />


module BooksModule {

    var app = angular.module("MyBooks", ['ui.bootstrap', 'ngSanitize']);

    app.filter("DateFormat", function () {
        return function (rawDate: string) {
            return new Date(parseInt(rawDate.substr(6)));
        };
    });


    app.filter("PriceFormat", function () {
        return function (rawPrice: number) {
            return (rawPrice.toFixed(2));
        };
    });

    enum BooksType {
        All = 1,
        AudioBooks = 2,
        EBooks = 3,
        News = 4,
        Upcoming = 5,
        SuperOccasions = 6
    }

    app.controller("BooksController", function ($scope, $http) {

        $scope.SearchPhrase = null;
        $scope.Result = [];
        $scope.DataList = []
        $scope.sortType = "name"
        $scope.sortReverse = true

        $scope.IsBookType = null;
        $scope.IsNewType = null;

        $scope.RestrictSearchPhrase = function (value: number, max) {
            if (value > max) {
                return false;
            }
        }
        $scope.FindBook = function (phrase)
        {
            console.log(phrase)
        }
        //OnLoad
        $http.get('/Books/GetAllBooks').then(function (d) {
            $scope.DataList = d.data;
            console.log(d.data)
        }, function (error) {
            alert('FAIL')
        })

        // Tab list
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

        function Search()
        {

        }
        $scope.LoadData = function (booksType: BooksType)
        {
            return GetData(booksType,null)
        }


        // Load Data on Tab click
         function GetData(booksType: BooksType, searchPhrase:any) {
            $scope.IsBookType  = booksType;
            let apiUrl: string = '';

            switch (booksType) {
                case BooksType.All:
                    {
                        apiUrl = '/Books/GetAllBooks';
                      
                    } break;
                case BooksType.AudioBooks:
                    {
                        apiUrl = '/Books/GetAudioBooks';
                      
                    } break;
                case BooksType.EBooks:
                    {
                        apiUrl = '/Books/GetEBooks';
                    } break;

                case BooksType.News:
                    {
                        apiUrl = '/Books/GetNews';
                    } break;

                case BooksType.Upcoming:
                    {
                        apiUrl = '/Books/GetUpComming';
                    } break;

                case BooksType.SuperOccasions:
                    {
                        apiUrl = '/Books/GetPromotions';
                    } break;
                default:
            }

            $http.get(apiUrl).then(function (d: any) {
                $scope.DataList = d.data;
            }, function (error, status) {
                console.log(error, status)
            })
        }
    });

}