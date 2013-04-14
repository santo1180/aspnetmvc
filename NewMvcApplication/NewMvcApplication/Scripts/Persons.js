
var PersonsVM = function (person) {
    var self = this;

    self.Id = ko.observable(person ? person.Id : 0);

    self.FirstName = ko.observable(person ? person.FirstName : '');

    self.MI = ko.observable(person ? person.MI : '');

    self.LastName = ko.observable(person ? person.LastName : '');

    self.FaceBookId = ko.observable(person ? person.FaceBookId : '');

    self.Email = ko.observable(person ? person.Email : '');

    self.TwitterId = ko.observable(person ? person.TwitterId : '');

    self.LinkedInId = ko.observable(person ? person.LinkedInId : '');

    self.BlogUrl = ko.observable(person ? person.BlogUrl : '');
}

var PersonCollection = function () {
    var self = this;
    self.Persons = ko.observableArray([]);

    var url = "/Person/ListJson";

    var refresh = function () {
        self.Persons.removeAll();
        
        $.getJSON(url + "?dattime" + new Date(), {}, function (data) {
            //self.Persons.removeAll();
            self.Persons(data);
        }).error(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        });
    };

    self.addeditrow =  ko.observable( new PersonsVM());

    self.editPerson = function (person) {
        self.addeditrow(person);
    };

    self.createnew = function ()
    {
        self.addeditrow(new PersonsVM());
    }

    self.updaterow = function () {
        if ($("form").valid()) {
            //call to $.ajax or equivalent goes in here.

            $.ajax({
                type: "post",
                url: "/Person/UpdatePerson",
                data: JSON.stringify(ko.toJS(self.addeditrow())),
                cache: false,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                async: false,
                success: function (data) {
                    if (data) {
                        refresh();
                    }
                },
                error: function (err) {
                    var err = JSON.parse(err.responseText);
                    var errors = "";
                    for (var key in err) {
                        if (err.hasOwnProperty(key)) {
                            errors += key.replace("profile.", "") + " : " + err[key];
                        }
                    }
                    $("<div></div>").html(errors).dialog({ modal: true, title: JSON.parse(err.responseText).Message, buttons: { "Ok": function () { $(this).dialog("close"); } } }).show();
                },
                complete: function () {
                }
            });
        }
    }
    refresh();
}


ko.applyBindings(new PersonCollection());