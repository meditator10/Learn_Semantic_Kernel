plugin是一组可以公开给 AI LLM 应用程序和服务的功能。Semantic Kernel 遵循 OpenAI 的插件规范，可以很方便地接入和导出插件(如基于 Bing, Microsoft 365, OpenAI 的插件)，这样可以让开发人员很简单地调用不同的插件服务。
除了兼容 OpenAI 的插件外，Semantic Kernel 内也有属于自己插件定义的方式。不仅可以在规定模版格式上定义 Plugins, 更可以在函数内定义 Plugins.

使用本地plugin
  ---TimePlugin
  ---NewsPlugin

通过Semantic kernel的Planning功能，类似于OpenAI的function calling，可以根据Kernel上设置的服务和插件资源去动态构建工作流。
![chat history](https://github.com/user-attachments/assets/4dd11b55-9e87-4f4d-9bfb-f05f00a04ef4)
