// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.KeyVault
{
    /// <summary>
    /// A class representing a collection of <see cref="VaultKeyVersionResource" /> and their operations.
    /// Each <see cref="VaultKeyVersionResource" /> in the collection will belong to the same instance of <see cref="VaultKeyResource" />.
    /// To get a <see cref="VaultKeyVersionCollection" /> instance call the GetVaultKeyVersions method from an instance of <see cref="VaultKeyResource" />.
    /// </summary>
    public partial class VaultKeyVersionCollection : ArmCollection, IEnumerable<VaultKeyVersionResource>, IAsyncEnumerable<VaultKeyVersionResource>
    {
        private readonly ClientDiagnostics _vaultKeyVersionKeysClientDiagnostics;
        private readonly KeysRestOperations _vaultKeyVersionKeysRestClient;

        /// <summary> Initializes a new instance of the <see cref="VaultKeyVersionCollection"/> class for mocking. </summary>
        protected VaultKeyVersionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VaultKeyVersionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VaultKeyVersionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vaultKeyVersionKeysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.KeyVault", VaultKeyVersionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VaultKeyVersionResource.ResourceType, out string vaultKeyVersionKeysApiVersion);
            _vaultKeyVersionKeysRestClient = new KeysRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, vaultKeyVersionKeysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VaultKeyResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VaultKeyResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified version of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual async Task<Response<VaultKeyVersionResource>> GetAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Get");
            scope.Start();
            try
            {
                var response = await _vaultKeyVersionKeysRestClient.GetVersionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified version of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<VaultKeyVersionResource> Get(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Get");
            scope.Start();
            try
            {
                var response = _vaultKeyVersionKeysRestClient.GetVersion(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the versions of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions
        /// Operation Id: Keys_ListVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VaultKeyVersionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VaultKeyVersionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VaultKeyVersionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultKeyVersionKeysRestClient.ListVersionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VaultKeyVersionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vaultKeyVersionKeysRestClient.ListVersionsNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the versions of the specified key in the specified key vault.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions
        /// Operation Id: Keys_ListVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VaultKeyVersionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VaultKeyVersionResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VaultKeyVersionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultKeyVersionKeysRestClient.ListVersions(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VaultKeyVersionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vaultKeyVersionKeysRestClient.ListVersionsNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VaultKeyVersionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(keyVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<bool> Exists(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(keyVersion, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual async Task<Response<VaultKeyVersionResource>> GetIfExistsAsync(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _vaultKeyVersionKeysRestClient.GetVersionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VaultKeyVersionResource>(null, response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/keys/{keyName}/versions/{keyVersion}
        /// Operation Id: Keys_GetVersion
        /// </summary>
        /// <param name="keyVersion"> The version of the key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyVersion"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyVersion"/> is null. </exception>
        public virtual Response<VaultKeyVersionResource> GetIfExists(string keyVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyVersion, nameof(keyVersion));

            using var scope = _vaultKeyVersionKeysClientDiagnostics.CreateScope("VaultKeyVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _vaultKeyVersionKeysRestClient.GetVersion(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, keyVersion, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VaultKeyVersionResource>(null, response.GetRawResponse());
                return Response.FromValue(new VaultKeyVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VaultKeyVersionResource> IEnumerable<VaultKeyVersionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VaultKeyVersionResource> IAsyncEnumerable<VaultKeyVersionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
