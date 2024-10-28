resource "azurerm_application_insights" "main" {
  name                = "${local.resource_name_prefix}-app-insights"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name

  application_type = "web"
}