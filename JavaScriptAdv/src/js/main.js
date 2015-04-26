/* create DOM task elements */
require.config(
{
    paths: {
        jquery : 'jquery-2.1.1.min'
    }
}
);
/* register event handlers */
//
define("taskApp",function(require, exports, module){
    var $ = require("jquery");  // var obj = kernel.Get<Tipo>();
    var tasks = require("tasks"); 

    function registerEventHandlers() {
        $("#new-task-button").on("click", tasks.add);
        $("#delete-all-button").on("click", tasks.clear);
        $("#save-button").on("click", tasks.save);
        $("#cancel-button").on("click", tasks.cancel);
        $("#task-list").on("click", ".delete-button", tasks.remove);
    }

    /* initialize application */
    /* IIFE */
    exports.init = function () {
        registerEventHandlers();
        tasks.render();
        };
});


require(["taskApp"],function(app){
    app.init();
});
