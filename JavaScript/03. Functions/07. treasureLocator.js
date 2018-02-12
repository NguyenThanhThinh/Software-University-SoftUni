function treasureLocator() {
    let points = arguments[0];

    for (let i = 0; i < points.length; i += 2) {
        let x = points[i];
        let y = points[i + 1];

        console.log(inIslandArea(x, y));
    }

    function inIslandArea(x, y) {
        if (x >= 1 && x <= 3 && y >= 1 && y <= 3)
            return "Tuvalu";
        if (x >= 8 && x <= 9 && y >= 0 && y <= 1)
            return "Tokelau";
        if (x >= 5 && x <= 7 && y >= 3 && y <= 6)
            return "Samoa";
        if (x >= 0 && x <= 2 && y >= 6 && y <= 8)
            return "Tonga";
        if (x >= 4 && x <= 9 && y >= 7 && y <= 8)
            return "Cook";
        return "On the bottom of the ocean";
    }
}

//treasureLocator([4, 2, 1.5, 6.5, 1, 3]);