const emptyColumn = [
    {header:''}
];

const emptyRow = {
    Category:'',
    Name:'',
    Material:'',
    Unit:'',
    Length:'',
    Area:'',
    Volume:'',
    AssemblyCode:'',
    EquipmentCost:'',
    MaterialCost:'',
    LaborCost:'',
    TotalCost:''
}

const allColumns = [
    {header:'Category',key:'Category'},
    {header:'Name',key:'Name'},
    {header:'Material',key:'Material'},
    {header:'Unit',key:'Unit'},
    {header:'Length',key:'Length'},
    {header:'Area',key:'Area'},
    {header:'Volume',key:'Volume'},
    {header:'AssemblyCode',key:'AssemblyCode'},
    {header:'EquipmentCost',key:'EquipmentCost'},
    {header:'MaterialCost',key:'MaterialCost'},
    {header:'LaborCost',key:'LaborCost'},
    {header:'TotalCost',key:'TotalCost'}
];

const categoryColumns = [
    {header:'Category',key:'category'},    
    {header:'EquipmentCost',key:'totalEquipmentCost'},
    {header:'MaterialCost',key:'totalMaterialCost'},
    {header:'LaborCost',key:'totalLaborCost'},
    {header:'TotalCost',key:'totalCost'}
];

const totalColumns = [
    {header:'Total Equipment Cost',key:'totalEquipmentCost'},
    {header:'Total Material Cost',key:'totalMaterialCost'},
    {header:'Total Labor Cost',key:'totalLaborCost'},
    {header:'Grand Total',key:'totalCost'}
];

const pdfTotalColumns = ['Total Equipment Cost','Total Material Cost','Total Labor Cost','Total Cost']

const pdfCategoryColumns = [
    {label:'Category', property:'category'},
    {label:'Equipment Cost', property:'totalEquipmentCost'},        
    {label:'Material Cost', property:'totalMaterialCost'},
    {label:'Labor Cost', property:'totalLaborCost'},
    {label:'Total Cost', property:'totalCost'}
];

const pdfFullColumns = [
    {label:'Category ',     property:'Category'},
    {label:'Name ',         property:'Name'},
    {label:'Material ',     property:'Material'},
    {label:'Unit ',         property:'Unit'},
    {label:'Length ',       property:'Length'},
    {label:'Area ',         property:'Area'},
    {label:'Volume ',       property:'Volume'},
    {label:'AssemblyCode ', property:'AssemblyCode'},
    {label:'EquipmentCost ',property:'EquipmentCost'},
    {label:'MaterialCost ', property:'MaterialCost'},
    {label:'LaborCost ',    property:'LaborCost'},
    {label:'TotalCost ',    property:'TotalCost'}
]

const exportCostData = {
    emptyColumn,
    emptyRow,
    allColumns,
    categoryColumns,
    totalColumns,
    pdfTotalColumns,
    pdfCategoryColumns,
    pdfFullColumns
}

module.exports = exportCostData;