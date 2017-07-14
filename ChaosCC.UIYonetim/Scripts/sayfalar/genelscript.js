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
            prevText: "Geri"
        });

    $('textarea#Yazi').froalaEditor();
});