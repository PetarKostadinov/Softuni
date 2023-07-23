const {gql} = require("apollo-server");

const typeDefs = gql`
  type Basic {
    symbol: String
    name: String
    exchange: String
    exchangeCode: String
    bridgeExchangeCode: String
    currency: String
  }

  type Quote {
    lastPrice: Float
    openPrice: Float
    high: Float
    low: Float
    previousClosePrice: Float
    change1Day: Float
    change1DayPercent: Float
    change1Week: Float
    change1WeekPercent: Float
    timeStamp: String
    volume: Int
  }

  type Item {
    symbolInput: String
    basic: Basic
    quote: Quote
  }

  type Data {
    items: [Item]
  }

  type Query {
    quotes: Data
  }
`;
module.exports = typeDefs
