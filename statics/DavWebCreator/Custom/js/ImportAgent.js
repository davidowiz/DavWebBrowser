let list_selected = 0,
    dialog_name = null;

var countOfTextFields = 0;

const innerHtml = "";

/*document.addEventListener('DOMContentLoaded', function() {
    createBrowser({ Title: 'Title' });
});*/

function onListItemClick(item) {
    if (list_selected != item) {
        document.getElementById("item" + item).style.color = "#00ff00";
        document.getElementById("item" + list_selected).setAttribute("class", "form-control");
        //document.getElementById("item" + item).setAttribute("class", "selected");
        document.getElementById("item" + list_selected).style.color = "black";
        list_selected = item;
    }
}

function onButtonClick(button) {
    if (dialog_name != null && dialog_name != "") {
        let inputpassword_value = null;

        if (document.getElementById("password_input") != null) {
            inputpassword_value = document.getElementById("password_input").value;
        }

        var textInputs = [];
        for (var i = 0; i < countOfTextFields; i++) {
            if (document.getElementById("text_input" + i) != null) {
                textInputs.push(document.getElementById("text_input" + i).value);
                console.log("Pushed: " + document.getElementById("text_input" + i).value);
            }
        }

        var textInputsSerialized = JSON.stringify(textInputs);

        mp.trigger("DIALOG_RESPONSE", dialog_name, button, list_selected, textInputsSerialized, inputpassword_value);
    }
}

function createTitle(titleElement) {
    innerHtml += "<h1>{titleElement.Title}</h1>";
    document.getElementById('DavWebCreator').innerHTML = "<h1>" + titleElement.Title + "</h1>";
}

function createBrowser(browser) {

    // document.getElementById("dialog").innerHTML = "<form>" + caption_str + info_str + list_items_str + inputs_str + buttons_str + "</form>";
    /* if (name != "") {
         dialog_name = name;
         list_selected = 0;

         let caption_str = "",
             info_str = "",
             list_items_str = "",
             inputs_str = "",
             buttons_str = "";

         if (caption != "") caption_str = "<div id='caption' class='form-group'>" + caption + "</div>";
         if (info != "") info_str = "<div id='body' class='form-group'>" + info + "</div>";
         if (list_items.length > 0) {
             list_items_str = "<div id='list' class='form-group'><ul>";
             for (i = 0; i < list_items.length; i++) {
                 if (i == list_selected) list_items_str += "<li class='form-control' id='item" + i + "' onclick='onListItemClick(" + i + ")'>" + list_items[i] + "</li>";
                 else list_items_str += "<li class='form-control' id='item" + i + "' onclick='onListItemClick(" + i + ")'>" + list_items[i] + "</li>";
             }
             list_items_str += "</ul></div>";
         }
         if (text_input.length > 0 || password_input) {
             inputs_str = "<div id='input' class='form-group'>";
             if (text_input.length > 0) {
                 countOfTextFields = text_input.length + 1;
                 for (i = 0; i < text_input.length; i++) {
                     inputs_str += "<input id='text_input" + i + "' class='form-control' type='text' placeholder='" + text_input[i] + "'/>";
                 }
             }
             if (password_input != "") {
                 inputs_str += "<input id='password_input' class='form-control' type='password' placeholder='" + password_input + "'/>";
             }
             inputs_str += "</div>";
         }
         if (buttons.length > 0) {
             buttons_str = "<div id='buttons' class='form-group'>";
             for (i = 0; i < buttons.length; i++) {
                 buttons_str += "<button id='" + i + "' type='button' class='form-control' onclick='onButtonClick(" + i + ")'>" + buttons[i] + "</button>";
             }
             buttons_str += "</div>";
         }

         //ok*/

}