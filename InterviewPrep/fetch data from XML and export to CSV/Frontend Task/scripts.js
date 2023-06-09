async function generateTable() {
    try {
        const table = document.getElementById("myTable");

        const response = await fetch("https://test.ce2s.net/Study.xml");
        if (!response.ok) {
            throw new Error("Failed to load XML data");
        }

        const xmlText = await response.text();
        const parser = new DOMParser();
        const xmlDoc = parser.parseFromString(xmlText, "text/xml");

        const result = xmlDoc.querySelector("Result");
        const items = result.querySelectorAll("Item");

        const row1 = table.insertRow(); // First row for keys
        const row2 = table.insertRow(); // Second row for values

        for (let i = 0; i < items.length; i++) {
            const item = items[i];
            const alias = item.getAttribute("alias");
            const fields = getFieldsByAlias(alias);

            for (let j = 0; j < fields.length; j++) {
                const field = fields[j];
                const xpath = getXPathByField(field);
                const value = getItemFieldValue(item, xpath);
                const formattedField = formatFieldName(field);
                createCell(row1, "th", formattedField); // Use formatted field name
                createCell(row2, "td", value);
            }
        }
    } catch (error) {
        console.error(error.message);
    }
}

function getFieldsByAlias(alias) {
    const fieldMapping = {
        sys_System: ["name"],
        sm_Study: ["item", "state"],
        sm_Task: ["keyed_name"],
        ar_SimulationResult: ["ar_resultname", "ar_resultvalue", "ar_resultunit", "ar_target_met"],
        re_Requirement: ["ar_conditionexp"],
    };

    return fieldMapping[alias] || [];
}

function getXPathByField(field) {
    const xpathMapping = {
        name: "./name",
        item: "./name",
        state: "./state",
        keyed_name: "./keyed_name",
        ar_resultname: "./ar_resultname",
        ar_resultvalue: "./ar_resultvalue",
        ar_resultunit: "./ar_resultunit",
        ar_target_met: "./ar_target_met",
        ar_conditionexp: "./ar_conditionexp",
    };

    return xpathMapping[field] || "";
}

function getItemFieldValue(item, xpath) {
    let fieldValue = "";
    const fieldElement = document.evaluate(xpath, item, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;

    if (fieldElement) {
        fieldValue = fieldElement.textContent;
    }

    return fieldValue;
}

function createCell(row, cellType, text) {
    const cell = document.createElement(cellType);
    cell.textContent = text;
    row.appendChild(cell);
}

function formatFieldName(field) {
    const fieldMapping = {
        name: 'System Used',
        item: 'Study Name',
        state: 'Study State',
        keyed_name: 'Task',
        ar_resultname: 'Result Name',
        ar_resultvalue: 'Result Value',
        ar_resultunit: 'Result Unit',
        ar_target_met: 'Target Met',
        ar_conditionexp: 'Condition Expression',
    };

    return fieldMapping[field] || field;
}

generateTable();
