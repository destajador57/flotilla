var DocumentosView = require('../views/speaker'),
    DocumentosModel = require('../models/dataAccess'),
    multer = require('multer'),
    mkdirp = require('mkdirp'),
    fs = require('fs'),
    fse = require('fs-extra');
//var dirname = 'C:/Produccion/Flotillas/Documentos/';
var dirname = 'C:/Produccion/Flotillas/flotillasCartaFactura/PublishFlotillasCartaFactura/Documentos/';


//Configuración de MULTER
var storage = multer.diskStorage({ //multers disk storage settings
    destination: function(req, file, cb) {
        //Direccion donde creara la carpeta req.query.contrato idContrato
        var getVin = file.fieldname.split('|');
        //var stats = fs.lstatSync(dirname + getVin[1]);
        // if(!stats.isDirectory()) {
        //     mkdirp(dirname + getVin[1], function(err) {
        //         if (err) console.error(err)
        //         else console.log('Carpeta Creada para Documentos')
        //         console.log('entre y cree')
        //         cb(null, dirname+getVin[1])
        //     });

        // }
        // if (stats.isDirectory()) {
        //     console.log('entre1')
        //     cb(null, dirname+getVin[1])
        // }
        fs.access(dirname + getVin[1], fs.F_OK, function(err) {
            if (!err) {
                cb(null, dirname + getVin[1])

            } else {
                mkdirp(dirname + getVin[1], function(err) {
                    if (err) console.error(err)
                    else console.log('Carpeta Creada para Documentos')
                    console.log('entre y cree')
                    cb(null, dirname + getVin[1])
                });
            }
        });


    },
    filename: function(req, file, cb) {
        var datetimestamp = Date.now();
        var datoImagen = file.fieldname.split('|');
        var modelTemp = new DocumentosModel({
            "SQL_user": "sa",
            "SQL_password": "S0p0rt3",
            "SQL_server": "192.168.20.18",
            "SQL_database": "Flotillas",
            "SQL_connectionTimeout": 60000
        });
        var params = [{
            name: 'vin',
            value: datoImagen[1],
            type: modelTemp.types.STRING
        }, {
            name: 'idDocumento',
            value: datoImagen[0],
            type: modelTemp.types.INT
        }, {
            name: 'valor',
            value: file.originalname,
            type: modelTemp.types.STRING
        }, {
            name: 'idUsuario',
            value: datoImagen[2],
            type: modelTemp.types.INT
        }];

        modelTemp.query('UPD_UNIDAD_PROPIEDAD_SP', params, function(error, result) {
            console.log(result);
            console.log(error);
            var consecutivo=null;
            if(result[0].valor==0){
                consecutivo='';
            }else{
                consecutivo='_'+result[0].valor;
            }
            //Aqui pongo el nombre del documento
            cb(null, datoImagen[0] + consecutivo + '.' + file.originalname.split('.')[file.originalname.split('.').length - 1])
        });


    }
});

var upload = multer({ //multer settings
    storage: storage
}).any();

var Documentos = function(conf) {
    this.conf = conf || {};

    this.view = new DocumentosView();
    this.model = new DocumentosModel(this.conf.connection);

    this.response = function() {
        this[this.conf.funcionalidad](this.conf.req, this.conf.res, this.conf.next);
    }

}

Documentos.prototype.post_uploadfile_data = function(req, res, next) {
    console.log('entre2');
    //Con req.query se obtienen los parametros de la url
    //Objeto que envía los parámetros
    //Referencia a la clase para callback
    var self = this;
    //Cargo el archivo
    //console.log(req.params.data);
    upload(req, res, function(err) {
        if (err) {
            res.json({
                error_code: 1,
                err_desc: err
            });
            return;
        }

        // var stats = fs.lstatSync('C:/Users/user/Desktop/back node/Documentos');
        // console.log(stats)
        // Is it a directory?
        // if (stats.isDirectory()) {
        //     fse.copy('C:/Users/user/Desktop/back node/back node/backAppMovil/app/upload/13_0.jpg', 'C:/Users/user/Desktop/back node/Documentos/', function(err) {
        //         if (err) return console.error(err)
        //         console.log("success!")
        //     });



        // }

    })

    //    var params = [
    //        {
    //            name: 'idTipoContrato',
    //            value: req.query.idTipoContrato,
    //            type: self.model.types.INT
    //                    }
    //    ];
    //
    //    this.model.query('SEL_DOCUMENTOS_SP', params, function (error, result) {
    //        self.view.speakJSON(res, {
    //            error: error,
    //            result: result
    //        });
    //    });
};









//Crea Carpeta para Documentos
Documentos.prototype.post_creaCarpeta_data = function(req, res, next) {
    var self = this;


    mkdirp('./app/' + req.query.idcontrato, function(err) {
        if (err) console.error(err)
        else console.log('Carpeta Creada para Documentos')
    });
};







module.exports = Documentos;
