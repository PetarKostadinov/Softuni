const symbols = 'FTSE:FSI,INX:IOM,EURUSD,GBPUSD,IB.1:IEU'; //,SHI:SHH
const url = `https://markets-data-api-proxy.ft.com/research/webservices/securities/v1/quotes?symbols=${symbols}`;

export async function fetchData() {

    try {
        const response = await fetch(url);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Failed to fetch data:', error);
        return null;
    }
};