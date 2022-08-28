export const toolboxCategories = {
  kind: "categoryToolbox",
  contents: [
    {
      kind: "category",
      name: "HTML",
      contents: [
        {
          kind: "category",
          name: "Base Frame",
          colour: "#f22010",
          contents: [
            {
              kind: "block",
              type: "document",
            },
            {
              kind: "block",
              type: "header",
            },
            {
              kind: "block",
              type: "content",
            },
          ],
        },
        {
          kind: "category",
          name: "Basics",
          colour: "#f26110",
          contents: [
            {
              kind: "block",
              type: "div",
            },
            {
              kind: "block",
              type: "regexInput",
            },
            {
              kind: "block",
              type: "h",
            },
            {
              kind: "block",
              type: "paragraph",
            },
            {
              kind: "block",
              type: "br",
            },
          ],
        },
        {
          kind: "category",
          name: "Lists",
          colour: "#f0f255",
          contents: [
            {
              kind: "block",
              type: "ul",
            },
            {
              kind: "block",
              type: "ol",
            },
            {
              kind: "block",
              type: "li",
            },
            {
              kind: "sep",
              gap: "10",
            },
            {
              kind: "block",
              type: "dd",
            },
            {
              kind: "block",
              type: "dt",
            },
            {
              kind: "block",
              type: "dl",
            },
          ],
        },
      ],
    },
    {
      kind: "sep",
      gap: "100",
    },
    {
      kind: "category",
      name: "CSS",
      contents: [
        {
          kind: "category",
          name: "Basic",
          colour: "#e32db6",
          contents: [
            {
              kind: "block",
              type: "style",
            },
            {
              kind: "block",
              type: "color",
            },
            {
              kind: "block",
              type: "background-color", //nu merge
            },
            {
              kind: "block",
              type: "font-size",
            },
            {
              kind: "block",
              type: "display",
            },
          ],
        },
      ],
    },
  ],
};
