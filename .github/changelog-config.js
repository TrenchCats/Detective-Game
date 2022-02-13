module.exports = {
  types: [
    { types: ["feat", "feature"], label: "🚀 New Features" },
    { types: ["fix", "bugfix"], label: "🐛 Bug Fixes" },
    { types: ["improvements", "enhancement", "imp"], label: "🛠 Improvements" },
    { types: ["perf"], label: "⚡️ Performance Improvements" },
    { types: ["build", "ci"], label: "📦 Build System" },
    { types: ["refactor"], label: "♻️ Refactors" },
    { types: ["doc", "docs"], label: "📚 Documentation Changes" },
    { types: ["test", "tests"], label: "🧪 Tests" },
    { types: ["breaking"], label: "🚨 Breaking Changes" },
    { types: ["style"], label: "🎨 Code Style Changes" },
    { types: ["chore"], label: "🧹 Chores" },
      { types: ["security"], label: "🔒 Security"},
    { types: ["other"], label: "Other Changes" },
  ],

  excludeTypes: ["other"],

  renderTypeSection: function (label, commits) {
    let text = `\n## ${label}\n`;

    commits.forEach((commit) => {
      text += `- ${commit.subject}\n`;
    });

    return text;
  },

  renderChangelog: function (release, changes) {
    const now = new Date();
    return `# ${release} - ${now.toISOString().substr(0, 10)}\n` + changes + "\n\n";
  },
};
