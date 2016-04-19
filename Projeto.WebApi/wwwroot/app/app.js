//Criando o modulo de trabalho -> app
var app = angular.module('app', ['ngRoute']);

//configurar as rotas do modulo
app.config(
    function ($routeProvider) {

        $routeProvider
            .when(
                '/produto/cadastro',
                {
                    templateUrl: '/pages/cadastro.html',
                    controller : 'cadastro-controller'
                }

            )
        .when(
                '/produto/consulta',
                {
                    templateUrl: '/pages/consulta.html',
                    controller: 'consulta-controller'
                }

            )
    }
);