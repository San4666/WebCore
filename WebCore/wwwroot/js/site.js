$(function() {
    $("#FirstName").typeahead({
        minLength: 3,
        source: function(request, response) {
            $.getJSON("/api/Employees",{LikeFirstName : request},function (data) {
                var result = $.map(data, function (item) {
                    return item.firstName;
                }); 
                response(result);
            });
           
        }
    });
});