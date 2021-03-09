
function clipboardSuccess() {
  Vue.prototype.$message({
    message: '复制成功',
    type: 'success',
    duration: 1500
  })
}

function clipboardError() {
  Vue.prototype.$message({
    message: '复制失败',
    type: 'error'
  })
}

const clipboard = function (text, event) {
    const clipboard2 = new ClipboardJS(event.target, {
    text: () => text
  })
    clipboard2.on('success', () => {
    clipboardSuccess()
    clipboard2.destroy()
  })
    clipboard2.on('error', () => {
    clipboardError()
    clipboard2.destroy()
  })
    clipboard2.onClick(event)
}
