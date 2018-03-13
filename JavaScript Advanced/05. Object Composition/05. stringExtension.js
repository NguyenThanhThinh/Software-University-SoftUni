(function () {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this.valueOf();
        }
        return this.valueOf();
    };

    String.prototype.ensureEnd = function (str) {
        if(!this.endsWith(str)) {
            return this.valueOf() + str;
        }

        return this.valueOf();
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    };

    String.prototype.truncate = function (n) {
        let result = this.valueOf();
        if(result.length < n) {
            return result;
        } else if (result.length > n){
            let lastSpaceIndex = result.lastIndexOf(' ');

            if (lastSpaceIndex === -1) {
                if (n < 4) {
                    result = '.'.repeat(n);
                } else {
                    result = result.slice(0, n - 3) + '...';
                }
            } else {
                while (result.length > n) {
                    result = result.slice(0, lastSpaceIndex);
                    lastSpaceIndex = result.lastIndexOf(' ');
                }
                result += '...';
            }
        }

        return result;
    };

    String.format = function (input) {
        for (let i = 1; i < arguments.length; i++) {
            input = input.replace('{' + (i - 1) + '}', arguments[i]);
        }
        return input;
    }
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox', 'quick', 'brown');
str = String.format('jumps {0} {1}', 'dog');
console.log(str);