app.controller(
    'consulta-controller',
    function ($scope, $http) {

        $scope.consultar = function () {

            $http.get("http://localhost:40383/api/produto/consultar")
                .success(
                    function (lista) {
                        $scope.produtos = lista;
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );

        }

    }
);