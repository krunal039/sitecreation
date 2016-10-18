var additionalMembersPicker;


(function () {
    'use strict';

    angular
        .module('app.wizard')
        .controller('FunctionTaxonomyController', functionTaxonomyController);
    //.value('urlparams', null);

    functionTaxonomyController.$inject = ['$scope'];

    function functionTaxonomyController($scope) {
        $scope.title = 'FunctionTaxonomyController';

        $scope.AddPrimaryMembers = function (data) {
            if (data != undefined) {
                var _resolvedMembers = jQuery.parseJSON(data);
                var _MembersEmail = [];
                for (var i = 0; i < _resolvedMembers.length; i++) {
                    _MembersEmail.push(_resolvedMembers[i].email);
                }
                $scope.siteConfiguration.primaryMembers = _MembersEmail;
                var Members = $('#ppPrimaryMembers').spPrimaryMembersPicker('get');
                $scope.siteConfiguration._resolvedMembers = Members;
            }
        }

        var context;
        var hostweburl = decodeURIComponent(getQueryStringParameter('SPHostUrl'));
        var appweburl = decodeURIComponent(getQueryStringParameter('SPAppWebUrl'));
        var spLanguage = decodeURIComponent(getQueryStringParameter('SPLanguage'));

        // resources are in URLs in the form:
        // web_url/_layouts/15/resource
        var scriptbase = hostweburl + "/_layouts/15/";

        //Load the js files and continue to the successHandler
        $.getScript(scriptbase + "SP.Runtime.js",
            function () {
                $.getScript(scriptbase + "SP.js",
                    function () {
                        $.getScript(scriptbase + "SP.RequestExecutor.js",
                             function () {
                                 context = new SP.ClientContext(appweburl);
                                 var factory = new SP.ProxyWebRequestExecutorFactory(appweburl);
                                 context.set_webRequestExecutorFactory(factory);
                             }
                        );
                    }
                );
            }
        );



        activate();


        function activate() {
            $log.info($scope.title + ' Activated');
            initSiteMembersPeoplePickers(context);
        }

        $scope.getEmailFromPicker = function (e) {
            var elem = angular.element(e.srcElement);
            alert(elem.val());
        }

        function initSiteMembersPeoplePickers(context) {

            // setup people pickers
            $('#ppPrimaryMembers').spPrimaryMembersPicker({
                onLoaded: function () {
                    if ($scope.siteConfiguration._resolvedMembers != undefined) {
                        var _resolvedMembers = $scope.siteConfiguration._resolvedMembers;
                        $(this).spPrimaryMembersPicker('set', _resolvedMembers);
                    }
                }
            });
        }

        //function to get a parameter value by a specific key
        function getQueryStringParameter(urlParameterKey) {
            var params = document.URL.split('?')[1].split('&');
            var strParams = '';
            for (var i = 0; i < params.length; i = i + 1) {
                var singleParam = params[i].split('=');
                if (singleParam[0] == urlParameterKey)
                    return singleParam[1];
            }
        }

    }

})();