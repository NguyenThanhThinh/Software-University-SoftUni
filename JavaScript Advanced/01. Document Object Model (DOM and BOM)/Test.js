function extract(){
    let text = 'Rakiya (Bulgarian brandy) is home-made liquor (alcoholic drink). It can be made of grapes, plums or other fruits (even apples).\n';
    let pattern = /\(([^)]+)\)/g;
    let matches = pattern.exec(text);
    let result = [];

    while(matches) {
        result.push(matches[1]);
        matches = pattern.exec(text);
    }

    return result.join('; ');
}