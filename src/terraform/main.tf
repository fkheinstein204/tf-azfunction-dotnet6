
resource "azurerm_resource_group" "main" {
  name     = "${local.resource_name_prefix}-rg"
  location = var.resource_group_location
}

resource "random_string" "name" {
  length  = 8
  special = false
  upper   = false
}

resource "random_integer" "main" {
  min = 001
  max = 999
}
data "azurerm_client_config" "current" {
}