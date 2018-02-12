function templateXmlFormat() {
    let xml = '<?xml version="1.0" encoding="UTF-8"?>\n';
    xml += '<quiz>\n';


    let questionsAnswers = arguments[0];

    for (let i = 0; i < questionsAnswers.length; i += 2) {
        let question = questionsAnswers[i];
        let answer = questionsAnswers[i + 1];

        fillInformation(question, answer);
    }

    function fillInformation(question, answer) {
        xml += '  <question>\n';
        xml += `    ${question}\n`;
        xml += '  </question>\n';
        xml += '  <answer>\n';
        xml += `    ${answer}\n`;
        xml += '  </answer>\n';
    }

    xml += '</quiz>';
    console.log(xml);
}

//templateXmlFormat(["Who was the forty-second president of the U.S.A.?", "William Jefferson Clinton"]);