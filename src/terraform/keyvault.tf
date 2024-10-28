resource "azurerm_key_vault" "kvault" {
  name                        = "${local.resource_name_prefix}-kv"
  location                    = azurerm_resource_group.main.location
  resource_group_name         = azurerm_resource_group.main.name
  enabled_for_disk_encryption = true
  tenant_id                   = data.azurerm_client_config.current.tenant_id
  soft_delete_retention_days  = 7
  purge_protection_enabled    = false

  sku_name = "standard"
}
resource "azurerm_key_vault_access_policy" "app-user" {
  key_vault_id = azurerm_key_vault.kvault.id
  tenant_id    = data.azurerm_client_config.current.tenant_id
  object_id    = data.azurerm_client_config.current.object_id

  key_permissions = ["Backup", "Delete", "Get", "List", "Purge", "Recover", "Restore"]
}
resource "azurerm_key_vault_access_policy" "function-user" {
  key_vault_id = azurerm_key_vault.kvault.id
  tenant_id    = data.azurerm_client_config.current.tenant_id
  object_id    = azurerm_user_assigned_identity.function.principal_id

  key_permissions = ["Get"]
}