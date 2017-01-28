angular.module("umbraco").controller("Store.ProductPickerController", function ($scope, $http) {
    
    //INIT
    //set the display to empty, then populate it
    $scope.model.displayValue = [];

    //reset if not an array
    if (!angular.isArray($scope.model.value)) {
        $scope.model.value = [];
    }
    
    //Prime the dialog data + sync with the ui display value
    $http.get("backoffice/api/ProductPicker/GetAllProducts").then(function (response) {
        $scope.overlay.products = response.data;

        //we have to do some basic mapping as the media-grid expects these 2 properties...
        _.each($scope.overlay.products, function (i) {
            i.thumbnail = i.PreviewImageUrl;
            i.name = i.Name;

            if ($scope.model.value.indexOf(i.Id) >= 0) {
                $scope.model.displayValue.push(i);
            }

        });
    });


    //Overlay configuration
    $scope.overlay = {
        title: "Choose Products",
        show: false,
        selected: [],

        select: function (item) {

            if (!item.selected) {
                item.selected = true;
                $scope.overlay.selected.push(item);
            } else {
                item.selected = false;
            }

        },

        submit: function (model) {

            _.each(model.selected, function (item) {

                if ($scope.model.value.indexOf(item.Id) < 0 && item.selected) {
                    $scope.model.value.push(item.Id);
                    $scope.model.displayValue.push(item);
                    item.selected = false;
                }
                
            });

            $scope.overlay.selected = [];
            $scope.overlay.show = false;
        }
    };

    $scope.remove = function (index) {
        $scope.model.value.splice(index, 1);
        $scope.model.displayValue.splice(index, 1);
    }


});