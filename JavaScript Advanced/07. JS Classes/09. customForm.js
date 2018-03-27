let result = (function () {
    class Textbox {
        constructor(selector, regex) {
            this._elements = $(selector);
            this.value = $(this._elements[0]).val();
            this._invalidSymbols = regex;
            this.onInput();
        }

        get elements() {
            return this._elements;
        }

        get value() {
            return this._value;
        }

        set value(value) {
            this._value = value;
            for (let element of this.elements) {
                $(element).val(value);
            }
        }

        isValid(){
            return !this._invalidSymbols.test(this.value);
        }

        onInput(){
            this.elements.on('input', (event) => {
                let text = $(event.target).val();
                this.value = text;
            });
        }
    }

    class Form {
        constructor(...textBoxes) {
            for (let textBox of textBoxes) {
                if (!textBox instanceof TextBox) {
                    throw new Error('Argument is not an instance of TextBox class');
                }
            }

            this._element = $('<div>').addClass('form');
            this._textboxes = textBoxes;
            for (let textBox of textBoxes) {
                this._element.append($(textBox.selector));
            }
        }

        submit() {
            let formValidity = true;
            for (let textBox of this._textboxes) {
                if (textBox.isValid()) {
                    $(textBox.selector).css('border', '2px solid green');
                } else {
                    $(textBox.selector).css('border', '2px solid red');
                    formValidity = false;
                }
            }

            return formValidity;
        }

        attach(selector) {
            $(selector).append(this._element);
        }
    }

    return {Textbox: TextBox, Form: Form};
})();

let Textbox = result.Textbox;
let Form = result.Form;
let username = new Textbox("#username",/[^a-zA-Z0-9]/);
let password = new Textbox("#password",/[^a-zA-Z]/);
username.value = "username";
password.value = "password2";
let form = new Form(username,password);
form.attach("#root");
