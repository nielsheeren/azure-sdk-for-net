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

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="VpnSiteLinkResource" /> and their operations.
    /// Each <see cref="VpnSiteLinkResource" /> in the collection will belong to the same instance of <see cref="VpnSiteResource" />.
    /// To get a <see cref="VpnSiteLinkCollection" /> instance call the GetVpnSiteLinks method from an instance of <see cref="VpnSiteResource" />.
    /// </summary>
    public partial class VpnSiteLinkCollection : ArmCollection, IEnumerable<VpnSiteLinkResource>, IAsyncEnumerable<VpnSiteLinkResource>
    {
        private readonly ClientDiagnostics _vpnSiteLinkClientDiagnostics;
        private readonly VpnSiteLinksRestOperations _vpnSiteLinkRestClient;

        /// <summary> Initializes a new instance of the <see cref="VpnSiteLinkCollection"/> class for mocking. </summary>
        protected VpnSiteLinkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VpnSiteLinkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VpnSiteLinkCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _vpnSiteLinkClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VpnSiteLinkResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VpnSiteLinkResource.ResourceType, out string vpnSiteLinkApiVersion);
            _vpnSiteLinkRestClient = new VpnSiteLinksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, vpnSiteLinkApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VpnSiteResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VpnSiteResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieves the details of a VPN site link.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual async Task<Response<VpnSiteLinkResource>> GetAsync(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.Get");
            scope.Start();
            try
            {
                var response = await _vpnSiteLinkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vpnSiteLinkName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VpnSiteLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the details of a VPN site link.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual Response<VpnSiteLinkResource> Get(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.Get");
            scope.Start();
            try
            {
                var response = _vpnSiteLinkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vpnSiteLinkName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VpnSiteLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the vpnSiteLinks in a resource group for a vpn site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks
        /// Operation Id: VpnSiteLinks_ListByVpnSite
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VpnSiteLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VpnSiteLinkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VpnSiteLinkResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vpnSiteLinkRestClient.ListByVpnSiteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VpnSiteLinkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VpnSiteLinkResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _vpnSiteLinkRestClient.ListByVpnSiteNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VpnSiteLinkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the vpnSiteLinks in a resource group for a vpn site.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks
        /// Operation Id: VpnSiteLinks_ListByVpnSite
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VpnSiteLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VpnSiteLinkResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VpnSiteLinkResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vpnSiteLinkRestClient.ListByVpnSite(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VpnSiteLinkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VpnSiteLinkResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _vpnSiteLinkRestClient.ListByVpnSiteNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VpnSiteLinkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(vpnSiteLinkName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual Response<bool> Exists(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(vpnSiteLinkName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual async Task<Response<VpnSiteLinkResource>> GetIfExistsAsync(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _vpnSiteLinkRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vpnSiteLinkName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VpnSiteLinkResource>(null, response.GetRawResponse());
                return Response.FromValue(new VpnSiteLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnSites/{vpnSiteName}/vpnSiteLinks/{vpnSiteLinkName}
        /// Operation Id: VpnSiteLinks_Get
        /// </summary>
        /// <param name="vpnSiteLinkName"> The name of the VpnSiteLink being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vpnSiteLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vpnSiteLinkName"/> is null. </exception>
        public virtual Response<VpnSiteLinkResource> GetIfExists(string vpnSiteLinkName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vpnSiteLinkName, nameof(vpnSiteLinkName));

            using var scope = _vpnSiteLinkClientDiagnostics.CreateScope("VpnSiteLinkCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _vpnSiteLinkRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, vpnSiteLinkName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VpnSiteLinkResource>(null, response.GetRawResponse());
                return Response.FromValue(new VpnSiteLinkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VpnSiteLinkResource> IEnumerable<VpnSiteLinkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VpnSiteLinkResource> IAsyncEnumerable<VpnSiteLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
