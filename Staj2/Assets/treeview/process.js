$(document).ready(function () {
    $("body").on("click", "a[data-mode]", function () {
        var mode = $(this).data("mode");
        var formData = new FormData();
        var buton = $(this);

        if (mode === "UrunGuncelle") {
            $(buton).data('url', "/Partial/GetUrunForm");
            formData.append("UrunID", $(buton).data("data1"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }
        else if (mode === "UrunIslem") {
            $(buton).data('url', "/Home/UrunIslem/");
            formData.append("UrunID", $(buton).data("data1"));
            formData.append("type", "Kaydet");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        //alert_v1("Bilgi", result.split("|")[1], function () { });
                        //$('#hoca_yabanciDil_datatable').DataTableT(hoca_yabanciDil_getir);
                        //$("#mdl").modal("hide");
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        else if (mode === "UrunSil") {
            $(buton).data('url', "/Partial/GetUrunSil/");
            ButtonExecute("modal", "#", buton, formData, function () {
            }, function () { }, "true", "#");
        }
        else if (mode === "UrunSilTamamla") {
            $(buton).data('url', "/Home/UrunIslem/");
            formData.append("UrunID", $(buton).data("data1"));
            formData.append("type", "Sil");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }

        if (mode === "KategoriGuncelle") {
            $(buton).data('url', "/Partial/GetKategoriForm");
            formData.append("KategoriID", $(buton).data("data1"));
            ButtonExecute("partial", "", this, formData, function () {
                $("#mdl").modal("show");
            }, function () { }, "false", "#dvMdlDialog");
        }

        else if (mode === "KategoriIslem") {
            $(buton).data('url', "/Home/KategoriIslem/");
            formData.append("KategoriID", $(buton).data("data1"));
            formData.append("type", "Kaydet");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        //alert_v1("Bilgi", result.split("|")[1], function () { });
                        //$('#hoca_yabanciDil_datatable').DataTableT(hoca_yabanciDil_getir);
                        //$("#mdl").modal("hide");
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");
            }
        }
        else if (mode === "KategoriSil") {
            $(buton).data('url', "/Partial/GetKategoriSil/");
            ButtonExecute("modal", "#", buton, formData, function () {
            }, function () { }, "true", "#");
        }
        else if (mode === "KategoriSilTamamla") {
            $(buton).data('url', "/Home/KategoriIslem/");
            formData.append("KategoriID", $(buton).data("data1"));
            formData.append("type", "Sil");
            if (FormValidate(buton)) {
                ButtonExecute("post", "#mdlForm", this, formData, function (result) {
                    if (result.split("|")[0] === "Ok") {
                        location.reload();
                    }
                    else {
                        alert_v1("Hata", result.split("|")[1], function () { });
                    }
                }, function () { }, "false", "");

            }
        }
    });
});