define(["jquery"], function($){
    "use strict";
    //var $ = require("jquery");

    var taskTemplate = '<li class="task"><input class="complete" type="checkbox" /> <input class="description" type="text" placeholder="Enter task description..." /> <button class="delete-button">Delete</button></li>';

    function _renderTask(task) {
        var $task = $(taskTemplate);
        if(task.complete) {
            $task.find(".complete").attr("checked", "checked");
        }
        $task.find(".description").val(task.description);
        return $task;
    }
    return {
        renderTasks :  function (tasks) {
            var elementArray = $.map(tasks, _renderTask);

            $("#task-list")
                .empty()
                .append(elementArray);
        },     
        new :function () {
            var $taskList = $("#task-list");
            $taskList.prepend(_renderTask({}));
        }
    };
   

});
