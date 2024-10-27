resource "azurerm_user_assigned_identity" "function" {
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  name                = "${local.resource_name_prefix}-uai-fn"
}