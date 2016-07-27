function WorkSchedule() {
    this.calcBusinessDays = function (date1, date2) { // input given as Date objects
        var a = moment(date2);
        var b = moment(date1);
        return a.diff(b, 'week') + 1;
    }
    this.addWork = function (input) {
        var div = $(input.parent().get(0));
        var divParent = $(input.parent().get(0).parentElement.parentElement);
        var dates = divParent.find("input");
        var tr = $("#actividad_" + div.attr('data-rel'));
        var children = tr.children("*");
        for (var i = 1; i < children.length; i++) {
            $(children[i]).remove();
        }
        var fe_inicio = dates[0];
        var fe_final = dates[1];
        if (fe_inicio.value && fe_final.value) {
            fe_inicio = new Date(fe_inicio.value);
            fe_final = new Date(fe_final.value);
            if (fe_final.getTime() >= fe_inicio.getTime()) {
                var p = $("<p></p>");
                var count = this.calcBusinessDays(fe_inicio, fe_final);
                p.text(count);
                var td = $("<td></td>");
                td.append(p);
                tr.append(td);
            } else {

            }
        }
    }

    this.prepare = function (inputs) {
        for (var i = 0; i < inputs.length; i++) {
            var input = $(inputs[i]);
            var date = new Date(input.val());
            var min = new Date('1973-01-01');
            if (date.getTime() == min.getTime()) {
                input.val("");
            }
        }
    }
};

schedule = new WorkSchedule();

$(document).ready(function () {
    schedule.prepare($('.input-group input'));

    $('.input-group input').on("change", function () {
        var input = $(this);
        schedule.addWork(input);
    });
});