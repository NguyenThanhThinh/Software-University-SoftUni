function ticketDatabase(destinations, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    for (let i = 0; i < destinations.length; i++) {
        let ticketTokens = destinations[i].split('|');
        let currentTicket = new Ticket(ticketTokens[0], ticketTokens[1], ticketTokens[2]);
        tickets.push(currentTicket);
    }

    switch (sortingCriteria) {
        case 'destination': tickets.sort((a, b) => a.destination > b.destination); break;
        case 'price': tickets.sort((a, b) => a.price > b.price); break;
        case 'status': tickets.sort((a, b) => a.status > b.status); break;
    }

    return tickets;
}

console.log(ticketDatabase(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));

