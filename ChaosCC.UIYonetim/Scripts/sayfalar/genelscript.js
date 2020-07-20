$(document).ready(function () {

    $(".datepicker").datepicker(
        {
            firstDay: 1,
            dateFormat: 'dd.mm.yy',
            dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Peşembe", "Cuma", "Cumartesi"],
            dayNamesMin: ["Paz", "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt"],
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmmuz", "Auğtos", "Eylül", "Ekim", "Kasım", "Aralık"],
            monthNamesShort: ["Ock", "Şbt", "Mrt", "Nis", "May", "Haz", "Tem", "Auğ", "Eyl", "Ekm", "Kas", "Ara"],
            nextText: "İleri",
            prevText: "Geri",            
        });

    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid();
    }

    //$('.picker').datepicker({
    //    dateFormat: 'dd.mm.yyyy',
    //    changeMonth: true,
    //    changeYear: true,
    //    selectOtherMonths: true
    //});

    //$('.datepicker').removeAttr("data-val-date");

    $('textarea#Yazi').froalaEditor();
    
    
    jQuery.validator.methods["date"] = function (value, element) { return true; };

    $.validator.addMethod('date', function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var valid = true;
        try {
            $.datepicker.parseDate('dd.mm.yy', value);
        }
        catch (err) {
            valid = false;
        }
        return valid;
    });
});

function Sil(controller,id) {
    if (confirm('Silmek istediğinize emin misiniz?')) {
        window.location = "/" + controller+"/Delete/" + id;
    }
}


function GetModeller(ddlMarka, ddlModel) {    
    $.getJSON("/Modeller/GetJson", { id: ddlMarka.val() },
        function (data) {
            ddlModel.empty();
            ddlModel.append($('<option/>', {
                val: null,
                text: "Seçiniz"
            }));
            $.each(data, function (index, itemData) {
                ddlModel.append($('<option/>', {
                    value: itemData.Id,
                    text: itemData.Adi
                }));
            });
        }
    );
}

function getSelectValues(select) {
    var result = [];
    var options = select && select.options;
    var opt;

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value || opt.text);
        }
    }
    return result;
}