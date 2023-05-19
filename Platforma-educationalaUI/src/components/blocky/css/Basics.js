import {
  generateInputBlockGeneral,
  generateDropDownBlockGeneral,
  generateDropDownAndInputBlockGeneral,
} from "./functionsCreateBlocks";

const basicColor = "#e32db6";

generateInputBlockGeneral("any", "#040806");
generateInputBlockGeneral("color", basicColor);
generateInputBlockGeneral("background-color", basicColor);
generateInputBlockGeneral("font-size", basicColor);
generateInputBlockGeneral("height", basicColor);
generateInputBlockGeneral("width", basicColor);
generateInputBlockGeneral("z-index", basicColor);
generateInputBlockGeneral("border", basicColor);
generateInputBlockGeneral("gap", basicColor);

//display
let optionsDisplay = [
  ["inline", "inline"],
  ["flex", "flex"],
  ["grid", "grid"],
  ["block", "block"],
  ["none", "none"],
];

generateDropDownBlockGeneral("display", optionsDisplay, basicColor);

let marginOptions = [
  ["margin", "margin"],
  ["margin-top", "margin-top"],
  ["margin-left", "margin-left"],
  ["margin-right", "margin-right"],
];

let paddingOptions = [
  ["padding", "padding"],
  ["padding-top", "padding-top"],
  ["padding-left", "padding-left"],
  ["padding-right", "padding-right"],
];

generateDropDownAndInputBlockGeneral("margin", marginOptions, basicColor);
generateDropDownAndInputBlockGeneral("padding", paddingOptions, basicColor);

//justify and align self
let alignOptions = [
  ["auto", "auto"],
  ["normal", "normal"],
  ["start", "start"],
  ["end", "end"],
  ["center", "center"],
  ["stretch", "stretch"],
  ["baseline", "baseline"],
];
generateDropDownBlockGeneral("justify-self", alignOptions, basicColor);
generateDropDownBlockGeneral("align-self", alignOptions, basicColor);

//justify and align content
let alignContentOptions = [
  ["baseline", "baseline"],
  ["space-between", "space-between"],
  ["space-around", "space-around"],
  ["auto", "auto"],
  ["normal", "normal"],
  ["start", "start"],
  ["end", "end"],
  ["center", "center"],
  ["stretch", "stretch"],
];

generateDropDownBlockGeneral("justify-content", alignContentOptions, basicColor);
generateDropDownBlockGeneral("align-content", alignContentOptions, basicColor);
