import "../blocky";
import { useEffect, useRef, useState } from "react";
import { BlocklyWorkspace, useBlocklyWorkspace } from "react-blockly";
import Blockly, { WorkspaceSvg } from "blockly";
import { toolboxCategories } from "./toolboxCategories";

export default function BlockyMain({ setHtml }: { setHtml: Function }) {
  const blocklyRef = useRef(null);
  const [javascriptCode, setJavascriptCode] = useState("");
  const initialXml = '<xml xmlns="http://www.w3.org/1999/xhtml"></xml>';

  function workspaceDidChange(workspace: WorkspaceSvg) {
    const code = (Blockly as any).JavaScript.workspaceToCode(workspace);
    if (workspace.getAllBlocks(true).length > 0) {
      workspace.scrollbar.setContainerVisible(true);
    } else {
      workspace.scrollbar.setContainerVisible(false);
    }
    setJavascriptCode(code);
    setHtml(code);
  }

  const { workspace, xml } = useBlocklyWorkspace({
    ref: blocklyRef,
    toolboxConfiguration: toolboxCategories as any,
    initialXml: initialXml,
    workspaceConfiguration: {
      grid: {
        spacing: 20,
        length: 3,
        colour: "#ccc",
        snap: true,
      },
    },
    onWorkspaceChange: workspaceDidChange,
    onImportXmlError: () => console.log("eroare xml import"),
    onInject: () => console.log("creating workspace"),
    onDispose: () => console.log("deleting workspace"),
  });

  useEffect(() => {
    if (!workspace) return;
    workspace.scrollbar.setContainerVisible(false);
  }, [workspace]);

  return (
    <>
      <div className="fill-height" ref={blocklyRef} />
      <textarea
        id="code"
        style={{ height: "200px", width: "400px" }}
        value={javascriptCode}
        readOnly
      ></textarea>
    </>
  );
}
