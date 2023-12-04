// Write your JavaScript code.

function getPictureData(table, field, id) {
    var fileModel = {
        Table: table,
        Column: field,
        Id: id,
    };

    $.ajax({
        url: '/Files/GetPictureData',
        type: 'GET',
        data: fileModel,
        success: function (data) {
            document.getElementById('fotoDisplay').src = data.data;
        }
    });
}

function previewFoto() {
    var input = document.getElementById('uploadFoto');
    var preview = document.getElementById('fotoDisplay');
    var file = input.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    };

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "/img/semFoto.svg"; // Imagem padrão se nenhum arquivo for selecionado
    }
}

var cidadesJSON = "";
var cidades = [
    //{ id: 1, nome: 'ÁGUA VERDE', latitude: -26.912400, longitude: -49.116100 },
    //{ id: 2, nome: 'BADENFURT', latitude: -26.882400, longitude: -49.153400 },
    //{ id: 3, nome: 'BOA VISTA', latitude: -26.904000, longitude: -49.068100 },
    //{ id: 4, nome: 'BOM RETIRO', latitude: -26.926300, longitude: -49.076600 },
    //{ id: 5, nome: 'CENTRO', latitude: -26.917500, longitude: -49.066800 },
    //{ id: 6, nome: 'GLÓRIA', latitude: -26.964270, longitude: -49.059020 },
    //{ id: 7, nome: 'SALTO', latitude: -26.883390, longitude: -49.102400 },
    //{ id: 8, nome: 'ESCOLA AGRÍCOLA', latitude: -26.895780, longitude: -49.099040 },
    //{ id: 9, nome: 'FIDÉLIS', latitude: -26.839800, longitude: -49.064600 },
    //{ id: 10, nome: 'FORTALEZA', latitude: -26.879400, longitude: -49.066700 },
    //{ id: 11, nome: 'FORTALEZA ALTA', latitude: -26.848280, longitude: -49.049750 },
    //{ id: 12, nome: 'GARCIA', latitude: -26.934900, longitude: -49.060400 },
    //{ id: 13, nome: 'ITOUPAVA CENTRAL', latitude: -26.812000, longitude: -49.090300 },
    //{ id: 14, nome: 'ITOUPAVA NORTE', latitude: -26.879690, longitude: -49.079210 },
    //{ id: 15, nome: 'ITOUPAVAZINHA', latitude: -26.852200, longitude: -49.114100 },
    //{ id: 16, nome: 'JARDIM BLUMENAU', latitude: -26.854330, longitude: -49.106530 },
    //{ id: 17, nome: 'NOVA ESPERANÇA', latitude: -26.887000, longitude: -49.051500 },
    //{ id: 18, nome: 'PASSO MANSO', latitude: -26.912800, longitude: -49.154200 },
    //{ id: 19, nome: 'PONTA AGUDA', latitude: -26.915150, longitude: -49.064240 },
    //{ id: 20, nome: 'PROGRESSO', latitude: -26.974100, longitude: -49.076000 },
    //{ id: 21, nome: 'RIBEIRÃO FRESCO', latitude: -26.927300, longitude: -49.048780 },
    //{ id: 22, nome: 'SALTO DO NORTE', latitude: -26.871600, longitude: -49.101000 },
    //{ id: 23, nome: 'SALTO WEISSBACH', latitude: -26.897600, longitude: -49.129500 },
    //{ id: 24, nome: 'TESTO SALTO', latitude: -26.849610, longitude: -49.146650 },
    //{ id: 25, nome: 'TRIBESS', latitude: -26.872020, longitude: -49.049900 },
    //{ id: 26, nome: 'VALPARAÍSO', latitude: -26.957830, longitude: -49.073490 },
    //{ id: 27, nome: 'VELHA', latitude: -26.918840, longitude: -49.092840 },
    //{ id: 28, nome: 'VELHA CENTRAL', latitude: -26.930110, longitude: -49.127310 },
    //{ id: 29, nome: 'VELHA GRANDE', latitude: -26.944160, longitude: -49.129420 },
    //{ id: 30, nome: 'VICTOR KONDER', latitude: -26.908990, longitude: -49.075580 },
    //{ id: 31, nome: 'VILA FORMOSA', latitude: -26.938420, longitude: -49.071500 },
    //{ id: 32, nome: 'VILA ITOUPAVA', latitude: -26.726440, longitude: -49.067370 },
    //{ id: 33, nome: 'VILA NOVA', latitude: -26.903640, longitude: -49.088490 },
    //{ id: 34, nome: 'VORSTADT', latitude: -26.904500, longitude: -49.037000 }
];

const manipuladorDeMapa = {
    Listar: () => {
        for (cidade of cidades) {
            L.marker([cidade.latitude, cidade.longitude])
                .addTo(map)
                .bindPopup(`Bairro: ${cidade.nome}, \n\nFocos: ${cidade.count}`)
                .openPopup();
        }
        //// Encontrar o bairro com base no id
        //const bairroEncontrado = cidades.find(bairro => bairro.id === idBairro);

        //// Verificar se o bairro foi encontrado
        //if (bairroEncontrado) {
        //    const { nome, latitude, longitude } = bairroEncontrado;

        //    // Adicionar marcador ao mapa
        //    L.marker([latitude, longitude])
        //        .addTo(map)
        //        .bindPopup(`Bairro: ${nome}, Focos: ${quantidade}`)
        //        .openPopup();
        //} else {
        //    console.error(`Bairro com ID ${idBairro} não encontrado.`);
        //}
    }
};