const axios = require('axios');

const symbols = 'FTSE:FSI,INX:IOM,EURUSD,GBPUSD,IB.1:IEU,SHI:SHH'; //,SHI:SHH
const API_URL = `https://markets-data-api-proxy.ft.com/research/webservices/securities/v1/quotes?symbols=${symbols}`;

const resolvers = {
    Query: {
        quotes: async () => {
            try {
                const response = await axios.get(API_URL);
                const {items} = response.data.data;
                const formattedItems = items.map(item => ({
                    symbolInput: item.symbolInput,
                    change1Day: item.quote.change1Day,
                    change1DayPercent: item.quote.change1DayPercent
                }));
                //console.log({items: formattedItems})
                return {items: formattedItems};
            } catch (error) {
                console.error('Error fetching quotes:', error);
                throw error;
            }
        }
    },
    Item: {
        quote: (parent) => parent, // Resolve the "quote" field directly from the parent object
    },

};

module.exports = resolvers;
