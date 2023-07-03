
import {fetchData} from './fetchData.js';
import {showSpiner} from './spiner.js';
import {symbolMappings} from './symbolMappings.js';

const appElement = document.getElementById('app');
let marketsDataWrapperDiv = '';
let marketsDataUnorderdList = '';
let marketsDataListItem = '';
let articleHoldingLink = '';
let itemChange = '';
let spanPlusMinus = '';
let percentage = '';

fetchData().then(buildUI);

function buildUI(data) {

    if (data) {
        createElementsAndShowMarketsData(data);
    } else {
        showSpiner();
    }
};

function createElementsAndShowMarketsData(data) {

    createDataWrapperDivAndUnorderdList();
    createListElementForEachItemAndAddData(data);
};

function createDataWrapperDivAndUnorderdList() {

    marketsDataWrapperDiv = document.createElement('div');
    marketsDataWrapperDiv.classList.add('markets-data-wrapper', 'js-markets-data');
    marketsDataUnorderdList = document.createElement('ul');
    marketsDataUnorderdList.classList.add('markets-data__items');

    appElement.appendChild(marketsDataWrapperDiv);
    marketsDataWrapperDiv.appendChild(marketsDataUnorderdList);
};

function createListElementForEachItemAndAddData(data) {

    data.data.items.forEach((item) => {

        if (item.quote.change1Day != 0) {

            marketsDataListItem = document.createElement('li');
            marketsDataListItem.classList.add('markets-data__item');
            marketsDataUnorderdList.appendChild(marketsDataListItem);

            addNameAndLinkFromMappedValueObject(item);
            addChange1DayPercent(item);

            itemChange.appendChild(spanPlusMinus);
            itemChange.appendChild(percentage);
            articleHoldingLink.appendChild(itemChange);
        }
    });
};

function addNameAndLinkFromMappedValueObject(item) {

    articleHoldingLink = document.createElement('a');
    articleHoldingLink.setAttribute('href', item.link);
    articleHoldingLink.classList.add('markets-data__item-link');
    marketsDataListItem.appendChild(articleHoldingLink);
    const itemSymbol = document.createElement('span');
    itemSymbol.classList.add('markets-data__item-name');

    const mappedValue = symbolMappings[item.basic.symbol.slice()];

    if (mappedValue) {
        itemSymbol.textContent = mappedValue.name;
        if (mappedValue.link) {
            articleHoldingLink.setAttribute('href', mappedValue.link);
        }
    } else {
        itemSymbol.textContent = item.basic.symbol.split(':')[0];
    }
    articleHoldingLink.appendChild(itemSymbol);
}

function addChange1DayPercent(item) {

    itemChange = document.createElement('span');
    itemChange.classList.add('markets-data__item-change');

    spanPlusMinus = document.createElement("span");
    percentage = document.createTextNode(Math.abs(item.quote.change1DayPercent.toFixed(2)) + '%');

    if (item.quote.change1Day > 0) {

        spanPlusMinus.textContent = "+";
        itemChange.classList.add('markets-data__item-change--up');

    } else {
        spanPlusMinus.textContent = "-";
        itemChange.classList.add('markets-data__item-change--down');
    }
};

export {
    addChange1DayPercent
}

