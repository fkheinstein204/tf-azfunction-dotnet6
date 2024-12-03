output "trim_name_resource" {
  value = local.storage_name
}
output "resource_group_name" {
  value = azurerm_resource_group.main.name
}
output "function_name" {
  value = azurerm_linux_function_app.fn_linux_app.name
}