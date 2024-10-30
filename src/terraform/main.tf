
resource "azurerm_resource_group" "main" {
  name     = "rg-${local.resource_name_prefix}"
  location = var.resource_group_location
}

resource "random_string" "name" {
  length  = 6
  special = false
  upper   = false
  numeric = false
}

resource "random_integer" "main" {
  min = 101
  max = 999
}
data "azurerm_client_config" "current" {
}