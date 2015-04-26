describe("The taskModule", function () {

    var injector;

    beforeEach(function (done) {
        require(["Squire"], function (Squire) {
            injector = new Squire();
            done();
        });
    });

    afterEach(function () {
        injector.remove();
    });


    describe("add function", function () {
        it("calls taskRenderer.renderNew", function (done) {
            injector.mock("views/taskRender", {
                new: function () {}
            });

            injector.mock("data/taskData", {});

            injector.require(["tasks", "views/taskRender"],
            	function (tasks, taskRenderer) {
	            	spyOn(taskRenderer, "new");
	                tasks.add();
	                expect(taskRenderer.new).toHaveBeenCalled();
	                done();
	            },
	            function (error) {
	            	done.error(error);
	            });
        });
    });
});