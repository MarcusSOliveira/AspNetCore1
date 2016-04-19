app.controller(
    'cadastro-controller',
    function ($scope, $http) {

        $scope.cadastrar = function () {

            $scope.mensagem = "Enviando requisição...";

            $http.post("http://localhost:40383/api/produto/cadastrar", $scope.produto)
                .success(
                    function (msg) {
                        $scope.mensagem = msg;
                        $scope.produto = {};
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