class sortedCollection {
    constructor() {
        this.collection = [];
        this.size = 0;
    }

    add(element) {
        this.collection.push(element);
        this.size++;
        this.sort();
    };

    remove(index) {
        if (index > -1 && index < this.collection.length) {
            this.collection.splice(index, 1);
            this.size--;
        }
    };

    get(index) {
        if (index > -1 && index < this.collection.length) {
            return this.collection[index];
        }
    };

    sort() {
        this.collection = this.collection.sort((a, b) => a - b);
    };

    toString() {
        return this.collection.join(' ');
    };
}
