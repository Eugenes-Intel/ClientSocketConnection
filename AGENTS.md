# SocketConnClient working guidance

This file is the canonical project instruction entry point. This solution provides the socket client
and shared wire models used by [FCI](../FiscalizationConnectorInterface/AGENTS.md), which in turn
serves ERP integrations such as [DFSAPI](../../Backend/DFS/DFSAPI/AGENTS.md). Read the
[Fintax architecture](../../Backend/Fintax/docs/architecture.md) for the hosted endpoint topology.

## Project map

| Area | Entry point |
|---|---|
| Published socket-client package and dependency pins | [Rootsware.Integration.SocketClient.csproj](Rootsware.Integration.SocketClient/Rootsware.Integration.SocketClient.csproj) |
| Client API and lifecycle | [Client package](Rootsware.Integration.SocketClient), [Services/SocketClient.cs](Rootsware.Integration.SocketClient/Services/SocketClient.cs) |
| Endpoint selection, request serialization, socket I/O | [Services/ClientInitProxy.cs](Rootsware.Integration.SocketClient/Services/ClientInitProxy.cs) |
| Shared published message models and codes | [Rootsware.Libraries.SocketCL](Rootsware.Libraries.SocketCL), [its project file](Rootsware.Libraries.SocketCL/Rootsware.Libraries.SocketCL.csproj) |

The solution contains two `net8.0` published libraries plus a separate `SocketConnClient` console
project. That console project is not an automated test suite. Package READMEs contain release history;
check current source when a historical statement conflicts with implementation.

## Transport and contract rules

- Preserve public interfaces, JSON message shapes, channel values, and numeric codes unless the task
  includes coordinated consumer/server compatibility work. Check both FCI and hosted dispatch when
  changing a wire contract.
- The current `ClientInitProxy` constructor resolves the local machine hostname to IPv4 and uses its
  first address with the supplied port. It does not explicitly choose `localhost`. This is evidence
  from local source; verify the restored package version before assuming a deployed consumer uses it.
- `Rootsware.Integration.SocketClient` references SocketCL directly within this solution.
  The sibling FCI project references SocketClient directly, so consumer builds compile local source.
  Preserve published package identities for independent package consumers.
- Preserve the layering: transport and shared models belong here; fiscal business logic belongs in
  FCI/hosted modules, and device configuration authority belongs to FAS through FAS_Adapters. Do not
  add a FAS-specific orchestration path to this generic transport library.
- Delegate sibling-repository edits after loading the destination's guidance. Coordinate package
  version changes with consumers, keeping published contracts available.

## Verification and working state

From this directory, use `dotnet restore SocketConnClient.sln`, then
`dotnet build SocketConnClient.sln --no-restore -p:GeneratePackageOnBuild=false` for code validation.
Package creation and publishing are separate actions. Restore may need private Rootsware feed access;
report failures without exposing tokens or changing credential files as an incidental workaround.

No dedicated automated test project is present. For transport changes, verify the actual affected
send/receive, connection, cancellation, and error behavior in an appropriate local test setup; a build
alone is not protocol validation. Running consumers can reach live fiscalization services.
Documentation changes need path/diff checks, not consumer startup.

Preserve the checkout's pre-existing source edits and inspect index and working-tree diffs before
editing. Save completed plans under `docs/planning/` and durable decisions under
`docs/project-memory.md` when needed. Keep credentials, private payloads, and certificate material
out of documentation/output. Preserve legitimate human authorship and omit assistant or tool
contribution credits.
