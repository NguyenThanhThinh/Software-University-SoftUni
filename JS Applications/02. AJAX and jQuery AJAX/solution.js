function attachEvents() {
    $('#refresh').click(getAllMessages);
    $('#submit').click(sendMessage);
    let messageTextBox = $('#messages');

    function getAllMessages() {
        messageTextBox.val('');
        $('#author').val('');
        $('#content').val('');
        $.get('https://messenger-6e591.firebaseio.com/.json').then(attachMessage);
    }

    function sendMessage() {
        let message = {
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        };

        let request = {
            method: 'POST',
            url: 'https://messenger-6e591.firebaseio.com/.json',
            data: JSON.stringify(message),
            success: getAllMessages
        };

        $.ajax(request);
    }

    function attachMessage(messages) {
        messageTextBox.val('');
        let chatHistory = '';

        for (let message in messages) {
            chatHistory += `${messages[message].author}: ${messages[message].content}\n`;
        }

        messageTextBox.val(chatHistory);
    }
}