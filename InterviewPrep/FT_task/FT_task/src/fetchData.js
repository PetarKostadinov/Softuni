// const symbols = 'FTSE:FSI,INX:IOM,EURUSD,GBPUSD,IB.1:IEU'; //,SHI:SHH
// const url = `https://markets-data-api-proxy.ft.com/research/webservices/securities/v1/quotes?symbols=${symbols}`;


// //https://markets-data-api-proxy.ft.com/research/webservices/securities/v1/quotes?symbols=FTSE:FSI,INX:IOM,EURUSD,GBPUSD,IB.1:IEU

// export async function fetchData() {

//     try {
//         const response = await fetch(url);
//         const data = await response.json();
//         return data;
//     } catch (error) {
//         console.error('Failed to fetch data:', error);
//         return {'error': error};
//     }
// };

const API_URL = 'http://localhost:3000/graphql';

const GET_QUOTES = `
  query {
    quotes {
      items {
        symbolInput
        quote {
          change1Day
          change1DayPercent
        }
      }
    }
  }
`;

export async function fetchData() {
  try {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        query: GET_QUOTES,
      }),
    });

    const result = await response.json();
    const data = result.data.quotes.items;
    console.log("🚀 ~ file: fetchData.js:49 ~ fetchData ~ data:", data)

    return data;
  } catch (error) {
    console.error('Failed to fetch data:', error);
    return [];
  }
}
