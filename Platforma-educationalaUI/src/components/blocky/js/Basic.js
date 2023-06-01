import Blockly from "blockly";
import { blockyValidation } from "../validation.ts";

const color = "#4fc0c4";

Blockly.Blocks["script"] = {
  init: function () {
    this.appendDummyInput().appendField("script");
    this.appendStatementInput("Content").setCheck(null);
    this.setPreviousStatement(true, null);
    this.setNextStatement(true, null);
    this.setColour(color);
  },
};

Blockly.JavaScript["script"] = function (block) {
  blockyValidation(block);
  var content = Blockly.JavaScript.statementToCode(block, "Content");
  return `<script> ${content} </script>`;
};

Blockly.Blocks["GetElementById"] = {
  init: function () {
    this.appendDummyInput()
      .appendField("Get Document By ")
      .appendField(new Blockly.FieldTextInput("id"), "id");

    this.appendStatementInput("Content").setCheck(null);
    this.setPreviousStatement(true, null);
    this.setNextStatement(true, null);
    this.setColour(color);
  },
};

Blockly.JavaScript["GetElementById"] = function (block) {
  blockyValidation(block);
  var content = Blockly.JavaScript.statementToCode(block, "Content");
  let id = block.getFieldValue("id");
  return `
      document.getElementById('${id}')${content.trim()}`;
};
