resource "azurerm_storage_account" "functions" {
  name                     = local.storage_name
  resource_group_name      = azurerm_resource_group.main.name
  location                 = azurerm_resource_group.main.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}
resource "azurerm_service_plan" "main" {
  name                = "${local.resource_name_prefix}-asp"
  resource_group_name = azurerm_resource_group.main.name
  location            = azurerm_resource_group.main.location
  os_type             = "Linux"
  sku_name            = "Y1"
}
resource "azurerm_linux_function_app" "fn_linux_app" {
  name                = "${local.resource_name_prefix}-func"
  resource_group_name = azurerm_resource_group.main.name
  location            = azurerm_resource_group.main.location

  storage_account_name       = azurerm_storage_account.functions.name
  storage_account_access_key = azurerm_storage_account.functions.primary_access_key
  service_plan_id            = azurerm_service_plan.main.id
  site_config {
    application_insights_key                = azurerm_application_insights.main.instrumentation_key
    application_insights_connection_string  = azurerm_application_insights.main.connection_string
    application_stack {
      dotnet_version = "8.0"
    }
    cors {
      allowed_origins     = ["https://portal.azure.com"]
      support_credentials = true
    }
  }
  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = 1,
     FUNCTIONS_WORKER_RUNTIME  = "dotnet-isolated" 
    "SCM_DO_BUILD_DURING_DEPLOYMENT" = true
  }

  identity {
    type         = "SystemAssigned, UserAssigned"
    identity_ids = [azurerm_user_assigned_identity.function.id]
  }
}
