class Stringer {
    constructor(innerString, innerLength){
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    get innerLength() {
        return this._innerLength;
    }
    set innerLength(value) {
        this._innerLength = value;
        this._innerLength = this._innerLength < 0 ? 0 : this._innerLength;
    }

    increase(length){
        this.innerLength += length;
    }

    decrease(length){
        this.innerLength -= length;
    }

    toString(){
        if(this.innerString.length > this.innerLength) {
            this.innerString = this.innerString.slice(0, this.innerLength) + '...';
        } else if (this.innerLength == 0) {
            this.innerString = '...';
        }

        return this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...
