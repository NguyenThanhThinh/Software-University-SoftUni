function solve(inputStrings) {
    let peopleWithSubscribers = new Map()
    let personSubscribedTo = new Map()

    for (var index = 0; index < inputStrings.length; index++) {
        var currentCommand = inputStrings[index];

        if (currentCommand.indexOf('-') === -1) {
            if (peopleWithSubscribers.has(currentCommand)) {
                continue
            }

            peopleWithSubscribers.set(currentCommand, [])
            personSubscribedTo.set(currentCommand, 0)

        } else {
            [firstPerson, secondPerson] = currentCommand.split('-')

            if (!peopleWithSubscribers.has(firstPerson) ||
                !peopleWithSubscribers.has(secondPerson)) {
                continue
            }

            if (firstPerson === secondPerson ||
                peopleWithSubscribers.get(secondPerson).indexOf(firstPerson) !== -1) {
                continue
            }

            let currentSubscribers = personSubscribedTo.get(firstPerson)
            personSubscribedTo.set(firstPerson, currentSubscribers + 1)

            peopleWithSubscribers.get(secondPerson).push(firstPerson)
        }
    }

    let desiredRow = Array.from(peopleWithSubscribers).sort((a, b) => {
        let resultCode = b[1].length - a[1].length
        if (resultCode === 0) {
            resultCode = personSubscribedTo.get(b[0]) - personSubscribedTo.get(a[0])
            return resultCode
        } else {
            return resultCode
        }
    })[0]

    console.log(desiredRow[0])
    for (var index = 0; index < desiredRow[1].length; index++) {
        var element = desiredRow[1][index];
        console.log(`${index + 1}. ${element}`)
    }
}