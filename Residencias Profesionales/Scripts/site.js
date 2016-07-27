function Application() {
    this.counterActivities;
    this.counterDeliverable;

    this.constructor = function () {
        this.counterActivities = 0;
        this.counterDeliverable = 0;
        this.load();
    }

    this.load = function () {
        var ce = $("#counterActividades");
        this.counterActivities = ce.val();
        var ca = $("#counterEntregables");
        this.counterDeliverable = ca.val();
    }

    this.addRegion = function (region, group, strlabel) {
        var counter = 0;
        if (group.includes("groupEntregable")) {
            this.counterDeliverable++;
            counter = this.counterDeliverable;
            $('#counterEntregables').val(counter);
        } else if (group.includes("groupActividad")) {
            this.counterActivities++;
            counter = this.counterActivities;
            $('#counterActividades').val(counter);
        }

        var collapse = $("#" + region);
        var newGroupDiv = $('<div id="' + group + counter + '" class="form-group"></div>');
        var label = $('<label class="control-label col-md-2">' + strlabel + ' #' + counter + '</label>');
        var newInputDiv = $('<div class="col-md-10"></div>');
        var input_group = $('<div class="input-group"></div>');
        var input = $('<input class="adddynamically control-label col-md-2 form-control" name="' + strlabel + '_' + counter + '" id="' + strlabel + '_' + counter + '" type="text" />');
        var del = $('<span class="input-group-addon" onclick="app.removeRegion(\'' + group + counter + '\')"><i class="glyphicon glyphicon-remove"></i></span>');
        input_group.append(input);
        input_group.append(del);
        newInputDiv.append(input_group);
        newGroupDiv.append(label);
        newGroupDiv.append(newInputDiv);
        collapse.append(newGroupDiv);
    }

    this.removeRegion = function(group) {
        if (group.includes("groupEntregable")) {
            if (this.counterDeliverable == 0) {
                return false;
            }
            this.counterDeliverable--;
            $('#counterEntregables').val(this.counterDeliverable);
        } else if (group.includes("groupActividad")) {
            if (this.counterActivities == 0) {
                return false;
            }
            this.counterActivities--;
            $('#counterActividades').val(this.counterActivities);
        }
        $("#" + group).remove();
    }

    this.summit = function (strform, url) {
        var form = $('#' + strform);
        if (form.valid()) {
            tinymce.triggerSave();            

            var serialize = form.serializeArray();
            $.ajax({
                type: 'POST',
                url: url,
                data: serialize,
                dataType: 'json',
                success: function (response) {
                    window.location.href = response.Url;
                },
                error: function (response) {
                    console.log(response.responseJSON);
                    console.log(response.responseText);
                }
            });
        }
    }

};

app = new Application();

$(document).ready(function () {
    app.load();
    var action;
    $(".number-spinner span").mousedown(function () {
        btn = $(this);
        input = btn.closest('.number-spinner').find('input');
        if (input.val() == "") {
            input.val(0);
        }
        if (btn.attr('data-dir') == 'up') {
            action = setInterval(function () {
                if (input.attr('max') == undefined || parseInt(input.val()) < parseInt(input.attr('max'))) {
                    input.val(parseFloat(input.val()) + 50.00);
                } else {
                    clearInterval(action);
                }
            }, 50);
        } else {
            action = setInterval(function () {
                if (input.attr('min') == undefined || parseInt(input.val()) > parseInt(input.attr('min'))) {
                    var value = parseFloat(input.val()) - 50.00;
                    input.val(value > 0 ? value: 0);
                } else {
                    clearInterval(action);
                }
            }, 50);
        }
    }).mouseup(function () {
        clearInterval(action);
    });

    $('.input-group.date').datepicker({
        clearBtn: true,
        language: "es",
        daysOfWeekDisabled: "0,6",
        daysOfWeekHighlighted: "1,2,3,4,5",
        calendarWeeks: true,
        todayBtn: "linked",
        todayHighlight: true,
        toggleActive: true,
        format: "yyyy-mm-dd"
    });
});