var FollowController = function () {
    var button;
    var init = function () {
        $(".js-toggle-follow").click(togglefollow);
    };
    var togglefollow = function (e) {
        button = $(e.target);
        if (button.hasClass("btn-default")) {
            createfollow();
        }
        else {
            deletefollow();
        }
    };
    var createAttendance = function () {
        $.post("/api/followings", { courseId: button.attr("data-user-id") })
            .done(done)
            .fail(fail);
    };
    var deletefollow = function () {
        $.ajax({
            url: "/api/followings/" + button.attr("data-user-id"),
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };
    var done = function () {
        var text = (button.text() == "Following") ? "Following?" : "Following";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    var fail = function () {
        alert("Something failed");
    };
    return {
        init: init
    }
}();