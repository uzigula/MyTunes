
/* task management */
//["jquery","taskData","taskRender"]
define(function(require, exports, module){
    "use strict";
    var $ = require("jquery");
    var taskData = require("repository/taskData");
    var taskRender = require("views/taskRender");

    function add() {
        taskRender.new();
    }

    function remove(clickEvent) {
        var taskElement = clickEvent.target;
        $(taskElement).closest(".task").remove();
    }

    function clear() {
        taskData.clear();
        render();
    }

    function save() {
        var tasks = [];
        $("#task-list .task").each(function (index, task) {
            var $task = $(task);
            tasks.push({
                complete: $task.find(".complete").prop('checked'),
                description: $task.find(".description").val()
            });
        });

        taskData.save(tasks);
    }

    function cancel() {
        render();
    }

    function render() {
        taskData.load();
        taskRender.renderTasks(taskData.load());
    }

    exports.add= add;
    exports.remove= remove;
    exports.clear= clear;
    exports.save = save;
    exports.cancel= cancel;
    exports.render= render;
});