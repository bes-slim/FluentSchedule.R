var FluentScheduleR = (function ($fs) {
    "use strict";
    var homeModule = function (config) {
        var defaults = {
            loaderElementClass: ".task-execution-loader",
            messageElementClass: ".task-execution-message",
            taskRunnerElementClass: ".task-invoker",
            taskRemoverElementClass: ".task-remove",
            taskRunSuccessElementClass: ".task-execution-success"
        };

        var initHub, initCommands;
        initHub = function ($connetion, $options) {
            $connetion.hub.loging = $options.log;
            var taskManager = $.connection.taskManager;
            $.extend(taskManager.client, {
                taskExecuting: function (data) {
                    var tdElement = $(".taskContainer td[data-task-name='" + data.task + "']");
                    tdElement.find(defaults.taskRunSuccessElementClass).hide();
                    tdElement.find(defaults.loaderElementClass).show();
                    tdElement.find(defaults.messageElementClass).html(data.message);
                },
                taskExecuted: function (data) {
                    var tdElement = $(".taskContainer td[data-task-name='" + data.task + "']");
                    tdElement.find(defaults.messageElementClass).html(data.message);
                    tdElement.find(defaults.loaderElementClass).hide();
                    tdElement.find(defaults.taskRunSuccessElementClass).show();
                },
                taskRemoved: function (data) {
                    var $trElement = $(".taskContainer td[data-task-name='" + data.task + "']").closest("tr");
                    $trElement.animate({ backgroundColor: "#fbc7c7" }, "fast").animate({ opacity: "hide" }, "slow");
                }
            });
            $.connection.hub.connectionSlow(function () {
                console.log("Alert: connection slow");
            });

            $.connection.hub.start().done(function () {
                console.log("App connected.");
            }).fail(function (err) {
                console.log("fail :" + err);
            });
            return taskManager;
        };

        initCommands = function ($taskManager) {
            $(defaults.taskRunnerElementClass).click(function () {
                var taskname = $(this).data("task-name");
                $taskManager.server.runScheduleImmediately(taskname);
            });
            $(defaults.taskRemoverElementClass).click(function () {
                var taskname = $(this).data("task-name");
                $taskManager.server.deleteTaskImmediately(taskname);
            });
        };

        return {
            init: function ($connetion, $options) {
                var $taskManager = initHub($connetion, $options);
                initCommands($taskManager);

            }
        };
    };
    $fs.HomeModule = homeModule;
    return $fs;
}(FluentScheduleR || (FluentScheduleR = {})));